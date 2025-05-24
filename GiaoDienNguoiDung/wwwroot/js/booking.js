var dataTable;

$(document).ready(function myfunction() {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblBooking').DataTable({
        "ajax": {
            url: '/booking/getall'
        },
        "colums": [
            { "data": "id", "width": "10%" }, 
            { "data": "name", "width": "10%" },
            { "data": "email", "width": "10%" },
            { "data": "phone", "width": "10%" },
            { "data": "status", "width": "10%" },
            { "data": "bookingdate", "width": "10%" },
            { "data": "checkindate", "width": "10%" },
            { "data": "checkoutdate", "width": "10%" },
        ]
    });
}
