import React, { useState } from "react";
import ReactSelect from "react-select";
import {
    addProcedureToPlan,
    getPlanProcedures,
    getProcedures,
    getUsers,
    assignUserToProcedure
}
    from "../../../api/api";


const PlanProcedureItem = ({ procedure, users, planId }) => {
    const [selectedUsers, setSelectedUsers] = useState(null);

    const handleAssignUserToProcedure = async (e) => {
        setSelectedUsers(e);
        // TODO: Remove console.log and add missing logic
        //console.log(e, procedure, users, planId,);
        let userIds = [];
        userIds = e.map(x => { return (x.value) })
        //console.log("test", userIds);
        await assignUserToProcedure(planId, procedure.procedureId, userIds)
        
    };

    return (
        <div className="py-2">
            <div>
                {procedure.procedureTitle}
            </div>

            <ReactSelect
                className="mt-2"
                placeholder="Select User to Assign"
                isMulti={true}
                options={users}
                value={selectedUsers}
                onChange={(e) => handleAssignUserToProcedure(e)}
            />
        </div>
    );
};

export default PlanProcedureItem;
