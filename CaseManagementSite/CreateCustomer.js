$(document).ready(function() {

    $("#CreateNewCustomer").click(function(){

        let customer = {
            firstName : $('#firstname').val(),
            lastName : $('#lastname').val(),
            addressLine : $('#addressline').val(),
            postalCode : $('#postalcode').val(),
            city : $('#city').val(),
            email : $('#email').val(),
            phone : $('#phone').val(),
            cases:"",
            comment:""
        }
        console.log(customer);

        fetch('http://localhost:56357/api/customers', {
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
    })
  });


// fetch('http://localhost:51940/api/customers', {
//     method: "POST",
//     body: JSON.stringify({

//         firstName: "Hoho",
//         lastName: "Gogo",
//         addressline: "test street",
//         postalCode: "23423",
//         city: "stockholm",
//         cases:"",
//         comment:""
//     }),
//     headers: {"Content-type":"application/json; charset=UTF-8"
//  }
// })
// .then(response => response.json()).then(json => console.log(json));