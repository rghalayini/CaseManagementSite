$(document).ready(function() {

    $("#CreateNewCustomer").click(function(){

        let customer = {
            firstName : $('#firstname').val(),
            lastName : $('#lastname').val(),
            addressLine : $('#addressline').val(),
            postalCode : $('#postalcode').val(),
            city : city = $('#city').val(),
            email : email = $('#email').val(),
            phone : phone = $('#phone').val()
        }
        fetch('http://localhost:51940/api/Customers', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(customer)
        })
        .then(res => res.json())
        .then(data => {
            console.log(data)
        })
        .catch(function(error) {
            console.log("error");
            console.log(error);
        });
        console.log(customer);
    })
 });
