function newCustomer(e) {
    e.preventDefault()

    var customer = {
        firstName : e.target["firstname"].value,
        lastName : e.target["lastname"].value,
        addressLine : e.target["addressline"].value,
        postalCode : e.target["postalcode"].value,
        city : e.target["city"].value,
        email : e.target["email"].value,
        phone : e.target["phone"].value
    }

    fetch('http://localhost:51940/api/customers', {
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
}

//window.onload=function(){

//var print=document.getElementById("createCustomerForm");
//console.log(print);
document.getElementById("createCustomerForm").addEventListener("submit", newCustomer())


//}


