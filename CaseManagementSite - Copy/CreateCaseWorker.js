function newCaseWorker(e) {
    //e.preventDefault()

    var caseworker = {
        firstName : e.target["firstname"].value,
        lastName : e.target["lastname"].value,
        email : e.target["email"].value,
        phone : e.target["phone"].value
    }

    fetch('http://localhost:51940/api/caseworkers', {
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
}

window.onload=function(){

//var print=document.getElementById("createCaseWorkForm");
//console.log(print);
document.getElementById("createCaseWorkForm").addEventListener("submit", newCaseWorker(e))

}


