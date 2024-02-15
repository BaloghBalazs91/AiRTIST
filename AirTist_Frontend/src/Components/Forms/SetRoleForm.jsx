import React from 'react';

const SetRoleForm = ({ handleSubmit, formdata, handleInputChange }) => {
    return (
        <form className='setRoleForm' onSubmit={handleSubmit}>
            <label>Username:</label>
            <input type='text' name='userName' value={formdata.userName} onChange={handleInputChange} required />
            <label>Role:</label>
            <select name='role' defaultValue={formdata.role} onChange={handleInputChange} required>
                <option value="" disabled>Select Role</option>
                <option value={"User"}>User</option>
                <option value={"Admin"}>Admin</option>
            </select>
            <button type='submit' className='submitBtn'>Submit</button>
        </form>
    )
}
export default SetRoleForm;