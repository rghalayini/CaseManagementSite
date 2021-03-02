$(document).ready(function() {

    $("#CreateCaseWorker").click(function(){

        let caseworker = {
            firstName : $('#workerfirstname').val(),
            lastName : $('#workerlastname').val(),
            email  : $('#workeremail').val(),
            phone : $('#workerphone').val()
        }
        fetch('http://localhost:51940/api/CaseWorkers', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(caseworker)
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
});