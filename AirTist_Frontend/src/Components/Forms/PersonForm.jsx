import React from 'react';

const PersonForm = ({ handleSubmit, formdata, handleInputChange }) => {
    return (
        <form onSubmit={handleSubmit} className='personForm'>
            <input type='text' placeholder='Name' name='Name' value={formdata.Name} onChange={handleInputChange} required />
            <input type='text' placeholder='Nickname' name='Nickname' value={formdata.Nickname} onChange={handleInputChange} required />
            <input type='text' placeholder='Age' name='Age' value={formdata.Age} onChange={handleInputChange} required />
            <input type='text' placeholder='Occasion' name='Occasion' value={formdata.Occasion} onChange={handleInputChange} required />
            <input type='text' placeholder='Profession' name='Profession' value={formdata.Profession} onChange={handleInputChange} required />
            <input type='text' placeholder='Hobbies' name='Hobbies' value={formdata.Hobbies} onChange={handleInputChange} required />
            <input type='text' placeholder='PositiveTraits' name='PositiveTraits' value={formdata.PositiveTraits} onChange={handleInputChange} required />
            <input type='text' placeholder='NegativeTraits' name='NegativeTraits' value={formdata.NegativeTraits} onChange={handleInputChange} required />
            <input type='text' placeholder='An Interesting Story' name='InterestingStory' value={formdata.InterestingStory} onChange={handleInputChange} style={{ height: '150px', /* Tetszőleges méret */ }} required />
            <button type='submit' className='submitBtn'>Send</button>
        </form>
    )
};
export default PersonForm;