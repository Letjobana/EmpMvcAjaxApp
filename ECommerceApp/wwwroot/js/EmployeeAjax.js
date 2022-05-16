function LoadPositions() {

    $('positionDropdown option').remove();
 
    $.ajax({
        type: 'GET',
        url: 'Designation/GetAllDesignation',
        success(data) {
            if (data !== null) {
                var s = '<option value="-1">Please Select a Position</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].position + '</option>';
                }
                $("#positionDropdown").html(s);  
            }
            console.log(data);
        }, error() {

        }
    })
}

function LoadData() {
    $.ajax({
        url: 'Employees/GetEmployees',
        type: 'GET',
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td>' + item.phone + '</td>';
                html += '<td>' + item.designationId + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function SaveData() {

    var res = Validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        Name: $('#txtName').val(),
        Email: $('#txtEmail').val(),
        Phone: $('#txtPhone').val(),
        DesignationId: $('#positionDropdown').val(),
    };

    $.ajax({
        url: 'Employees/AddEmployee',
        type: 'POST',
        data: { employee: empObj },
        success: function (data) { 
            LoadData();
            $('#employeeModal').modal('hide');
            clearTextBox();
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function UpdateData() {

    var res = Validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        iD: $('#txtId').val(),
        Name: $('#txtName').val(),
        Email: $('#txtEmail').val(),
        Phone: $('#txtPhone').val(),
        DesignationId: $('#positionDropdown').val(),
    };

    $.ajax({
        url: 'Employees/UpdateEmployee',
        type: 'POST',
        data: { employee: empObj },
        success: function (data) {
            LoadData();
            $('#employeeModal').modal('hide');
            clearTextBox();
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function getbyID(empId) {
    $.ajax({
        url: 'Employees/GetEmployeeById',
        type: "GET",
        data: { empId: empId },
        success: function (result) {
            $('#txtId').val(result.id);
            $('#txtName').val(result.name);
            $('#txtEmail').val(result.email);
            $('#txtPhone').val(result.phone);
            $('#txtdesignationId').val(result.DesignationId);
            $('#employeeModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Delele(Id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Employees/DeleteEmployee/",
            data: { Id: Id },
            type: "DELETE",
            success: function (result) {
                LoadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function searchEmployee() {
    //var position = $("#positionDropdown option:selected").val();

    //$.ajax({
    //    url: 'Search/SearchEmployees',
    //    type: "GET",
    //    data: { employee: position },
    //    success: function (result) {
    //        console.log(result);
    //    },
    //    error: function (errormessage) {
    //        alert(errormessage.responseText);
    //    }
    //});
    alert('Just testing');
}

