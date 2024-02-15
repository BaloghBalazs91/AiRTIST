import React, { useState } from 'react';
import axios from 'axios';
import PersonForm from '../Components/Forms/PersonForm';

const CreatePoem = () => {
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

    const handleInputChange = (e) => {
        setFormData({ ...formdata, [e.target.name]: e.target.value });
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('api/User/GenerateText', formdata);

            if (response && response.data) {
                console.log(response.data);
                setResponseState(response.data);
            } else {
                console.error('Invalid response:', response);
                setResponseState(response.data);
            }
        } catch (error) {
            if (error.response && error.response.data) {
                console.error('Setting role failed:', error.response.data);
                setResponseState(error.response.data);
            } else {
                console.error('Unexpected error:', error);
                setResponseState(error.response.data);
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
                responseState.message === 'Request failed with status code 405' ? (
                    <div className='createPoem'>
                        <div className='error-text'>
                            Request failed with status code 405
                        </div>
                        <PersonForm
                            handleSubmit={handleSubmit}
                            formdata={formdata}
                            handleInputChange={handleInputChange}
                        />
                    </div>
                ) : (
                    <div>
                        {responseState.completion.choices[0].message.content}
                    </div>
                )
            )}
        </div>
    );
};

export default CreatePoem;
