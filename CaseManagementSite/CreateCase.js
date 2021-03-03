$(document).ready(function() {
    $("#CreateNewCase").click(function(){

        var _case = {
            caseWorkerId : $('#caseworkerbox').val(),
            customerId : $('#customerbox').val(),
            caseStatusId : $('#statusbox').val(),
            title : $('#title').val(),
            description : $('#description').val(),
            created : new Date(),
            modified : new Date()
        }

    fetch('http://localhost:56357/api/cases', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(_case)
        })
        .then(res => res.json())
        .then(data => {
            console.log(data)
        })
        .catch(function(error) {
            console.log("error");
            console.log(error);
        });
    })

    function getStatus(){
        fetch('http://localhost:56357/api/casestatus')
            .then(res => res.json())
            .then(data => {
                let options = data.map(option => `<option value="${option.id}">${option.status}</option>`)
                document.getElementById("statusbox").innerHTML = options
            })
    }
    function getCustomers(){
        fetch('http://localhost:56357/api/customers')
            .then(res => res.json())
            .then(data => {
                let options = data.map(option => `<option value="${option.id}">${option.firstName} ${option.lastName}</option>`)
                document.getElementById("customerbox").innerHTML = options
            })
    }
    function getCaseWorkers(){
        fetch('http://localhost:56357/api/caseworkers')
            .then(res => res.json())
            .then(data => {
                let options = data.map(option => `<option value="${option.id}">${option.firstName} ${option.lastName}</option>`)
                document.getElementById("caseworkerbox").innerHTML = options
            })
    }
    getStatus();
    getCustomers();
    getCaseWorkers();

});
