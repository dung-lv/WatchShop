$(document).ready(function () {

    $('.btn-update-product').click(function () {
        var name = $(this).closest('tr').find('.name-product').text();
        var quantity = $(this).closest('tr').find('.quantity-product').text();
        var price = $(this).closest('tr').find('.price-product').text();
        var id = $(this).closest('tr').find('.id-product').text();
        var metatitle = $(this).closest('tr').find('.metatitle-product').text();
        var description = $(this).closest('tr').find('.description-product').text();
        var content = $(this).closest('tr').find('.content-product').text();

        $("input[name=name]").val(name);
        $("input[name=price]").val(price);
        $("input[name=quantity]").val(quantity);
        $("input[name=ID_Product]").val(id);
        $("input[name=metatitle]").val(metatitle);
        $("textarea[name=description]").val(description);
        $("textarea[name=content]").val(content);
    });

    $('.btn-delete-product').click(function (e) {
        e.preventDefault();
        $.ajax({
            data: { id: $(this).data('id') },
            url: '/Admin/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/Admin/Index";
                }
            }
        })
    });

    $('#btnSend').click(function () {
        var name = $('#txtName').val();
        var phone = $('#txtPhone').val();
        var address = $('#txtAddress').val();
        var email = $('#txtEmail').val();
        var content = $('#txtContent').val();

        $.ajax({
            url: '/Contact/Send',
            type: 'POST',
            dataType: 'json',
            data: {
                name: name,
                mobile: mobile,
                address: address,
                email: email,
                content: content
            },
            success: function (res) {
                if (res.status == true) {
                    window.alert('Gửi thành công');
                    resetForm();
                }
            }
        });
    });

    function resetForm() {
        $('#txtName').val('');
        $('#txtPhone').val('');
        $('#txtAddress').val('');
        $('#txtEmail').val('');
        $('#txtContent').val('');
    }

    $('.btn-update-promotion').click(function () {
        var name = $(this).closest('tr').find('.name-promotion').text();
        var startTime = $(this).closest('tr').find('.startTime-promotion').text();
        var endTiem = $(this).closest('tr').find('.endTime-promotion').text();
        var description = $(this).closest('tr').find('.description-promotion').text();


        $("input[name=Name]").val(name);
        $("input[name=StartTime]").val(startTime);
        $("input[name=EndTime]").val(endTiem);
        $("textarea[name=Description]").val(description);

    });

    $('.btn-delete-promotion').click(function (e) {
        e.preventDefault();
        $.ajax({
            data: { id: $(this).data('id') },
            url: '/AdminPromotion/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/Admin/Index";
                }
            }
        })
    });

    
        $('#input-date-dob').datepicker({ format: "dd/mm/yyyy" });
        $('#end-date').click(function () {
            $('#input-date-dob').datepicker({ format: "dd/mm/yyyy" });
        });
        $('#start-date').datepicker({ format: "dd/mm/yyyy" });
        
   


});