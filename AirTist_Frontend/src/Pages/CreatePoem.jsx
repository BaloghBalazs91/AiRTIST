import React, { useState } from 'react';
import axios from 'axios';
import PersonForm from '../Components/Forms/PersonForm';
import { useAuth } from '../Components/AuthContext';

const CreatePoem = () => {
  const { userID } = useAuth(); // Kivesszük a userID-t az AuthContextből
  const [formdata, setFormData] = useState({
    Name: '',
    Nickname: '',
    Age: '',
    Occasion: '',
    Profession: '',
    Hobbies: '',
    PositiveTraits: '',
    NegativeTraits: '',
    InterestingStory: ''
  });

  const [responseState, setResponseState] = useState('');
  const [errorState, setErrorState] = useState('');

  const handleInputChange = (e) => {
    setFormData({ ...formdata, [e.target.name]: e.target.value });
  };

  const savePoem = async () => {
    try {
        console.log('userID:', userID);
      const response = await axios.post('/api/User/AddPoem', {
        poemString: responseState,
        userID: localStorage.getItem('Id')
      });

      if (response && response.data) {
        console.log('Poem saved successfully:', response.data);
      } else {
        console.error('Invalid response:', response);
        setErrorState(`Invalid response or error occurred: ${JSON.stringify(response)}`);
      }
    } catch (error) {
      if (error.response && error.response.data) {
        console.error('Poem saving failed:', error.response.data);
        setErrorState(`Error: ${JSON.stringify(error.response.data)}`);
      } else {
        console.error('Unexpected error:', error);
        setErrorState(`Unexpected error occurred: ${error.message}`);
      }
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setErrorState('');

    const prompt = `name: ${formdata.Name}, nickName: ${formdata.Nickname}, age: ${formdata.Age}, occasion: ${formdata.Occasion}, profession: ${formdata.Profession}, hobbies: ${formdata.Hobbies}, positiveTraits: ${formdata.PositiveTraits}, negativeTraits: ${formdata.NegativeTraits}, interestingStory: ${formdata.InterestingStory}`;

    try {
      const response = await axios.post('/api/User/GenerateText', { prompt });

      if (response && response.data) {
        console.log(response.data);
        setResponseState(response.data.content || 'No content generated.');
      } else {
        console.error('Invalid response:', response);
        setErrorState(`Invalid response or error occurred: ${JSON.stringify(response)}`);
      }
    } catch (error) {
      if (error.response && error.response.data) {
        console.error('Setting role failed:', error.response.data);
        setErrorState(`Error: ${JSON.stringify(error.response.data)}`);
      } else {
        console.error('Unexpected error:', error);
        setErrorState(`Unexpected error occurred: ${error.message}`);
      }
    }
  };

  return (
    <div>
      {responseState === '' ? (
        <div className='createPoem'>
          <PersonForm
            handleSubmit={handleSubmit}
            formdata={formdata}
            handleInputChange={handleInputChange}
          />
        </div>
      ) : (
        <div>
          <pre>{responseState}</pre>
          <button onClick={savePoem}>Save Poem</button>
        </div>
      )}
      {errorState && (
        <div className="error">
          <pre>{errorState}</pre>
        </div>
      )}
    </div>
  );
};

export default CreatePoem;