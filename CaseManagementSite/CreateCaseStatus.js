$(document).ready(function() {

     $("#CreateCaseStatus").click(function(){

        var casestatus = {
            status : $('#status').val()
        }
        fetch('http://localhost:56357/api/casestatus', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(casestatus)
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
