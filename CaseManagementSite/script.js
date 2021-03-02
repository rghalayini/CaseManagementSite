//document.getElementById("createCustomerForm").addEventListener("submit", newCustomer(e))
//document.getElementById("createCaseWorkerForm").addEventListener("submit", newCaseWorker(e))
//document.getElementById("createCaseStatusForm").addEventListener("submit", newCaseStatus(e))
//document.getElementById("createCaseForm").addEventListener("submit", newCase(e))

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

function newCaseWorker(e) {
    e.preventDefault()

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

function newCaseStatus(e) {
    e.preventDefault()

    var casestatus = {
        status : e.target["status"].value
    }

    fetch('http://localhost:51940/api/casestatus', {
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
}

function newCase(e) {
    e.preventDefault()

    var _case = {
        caseWorkerId : parseInt(e.target["caseworkerbox"].value),
        customerId : parseInt(e.target["customerbox"].value),
        caseStatusId : parseInt(e.target["statusbox"].value),
        title : e.target["title"].value,
        description : e.target["description"].value,
        created : new Date(),
        modified : new Date()
    }

    fetch('http://localhost:51940/api/cases', {
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
}

function getStatus(){
    fetch('http://localhost:51940/api/casestatus')
        .then(res => res.json())
        .then(data => {
            let options = data.map(option => `<option value="${option.id}">${option.status}</option>`)
            document.getElementById("statusbox").innerHTML = options
        })
}
function getCustomers(){
    fetch('http://localhost:51940/api/customers')
        .then(res => res.json())
        .then(data => {
            let options = data.map(option => `<option value="${option.id}">${option.firstName} ${option.lastName}</option>`)
            document.getElementById("customerbox").innerHTML = options
        })
}
function getCaseWorkers(){
    fetch('http://localhost:51940/api/caseworkers')
        .then(res => res.json())
        .then(data => {
            let options = data.map(option => `<option value="${option.id}">${option.firstName} ${option.lastName}</option>`)
            document.getElementById("caseworkerbox").innerHTML = options
        })
}

function getCases(){
    fetch('http://localhost:51940/api/cases')
        .then(res => res.json())
        .then(data => {
            let cases = data.map(_case =>
                `<tr>
                    <td>${_case.id}</td>
                    <td>${_case.caseStatus.status}</td>
                    <td>${_case.customer.firstName} ${_case.customer.lastName}</td>
                    <td>${_case.caseWorker.firstName} ${_case.caseWorker.lastName}</td>
                    <td>${_case.title}</td>
                    <td>${_case.description}</td>
                    <td>${_case.created}</td>

                </tr>`
            )
            document.getElementById("casetablebody").innerHTML = cases
        })
}

getStatus();
getCustomers();
getCaseWorkers();


