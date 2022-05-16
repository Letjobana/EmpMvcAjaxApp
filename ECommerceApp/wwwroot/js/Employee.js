$(document).ready(function () {
    LoadPositions();
    LoadData();
});
function Clearall() {
    $('#txtCode').val();
    $('#txtName').val();
    $('#txtEmail').val();
    $('#txtPhone').val();
    $('positionDropdown').val();
}

var empObj = {
    Name: $('#txtName').val(),
    Email: $('#txtEmail').val(),
    Phone: $('#txtPhone').val(),
    DesignationId: $('#positionDropdown').val(),
};

function clearTextBox() {
    $('#txtCode').val("");
    $('#txtEmail').val("");
    $('#txtPhone').val("");
    $('positionDropdown').val("");
    $('#txtCode').css('border-color', 'lightgrey');
    $('#txtEmail').css('border-color', 'lightgrey');
    $('#txtPhone').css('border-color', 'lightgrey');
    $('#positionDropdown').css('border-color', 'lightgrey');
}

function Validate() {
    var isValid = true;
    var position = $("#positionDropdown option:selected").val();
    
    if ($('#txtName').val().trim() === "") {
        $('#txtName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtName').css('border-color', 'lightgrey');
    }
    if ($('#txtEmail').val().trim() == "") {
        $('#txtEmail').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEmail').css('border-color', 'lightgrey');
    }
    if ($('#txtPhone').val().trim() === "") {
        $('#txtPhone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEmail').css('border-color', 'lightgrey');
    }
    if (position === '-1') {
        $('#positionDropdown').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#positionDropdown').css('border-color', 'lightgrey');
    }
    return isValid;
}

$("#addEmployee").click(function () {
    alert('Just Testing');

});

