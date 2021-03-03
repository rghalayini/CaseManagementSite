$(document).ready(function() {

    fetch('http://localhost:56357/api/Cases')
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

});