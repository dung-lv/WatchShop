$(document).ready(function () {

    function formatNumber(nStr, decSeperate, groupSeperate) {
        nStr += '';
        x = nStr.split(decSeperate);
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + groupSeperate + '$2');
        }
        return x1 + x2;
    }

    $('.cls_quantity').keyup(function () {
        var quantity = $(this).val();
        var price = $(this).closest('tr').find('.price').text().replace(/\D/g, '').replace(' đ', '').trim();
        var total = parseInt(quantity) * parseInt(price);
        $(this).closest('tr').find('.total').text(formatNumber(total, '.', ',') + " đ");
        var totalAll = 0;
        $('.table-cart tbody tr').each(function () {
            totalAll += parseInt($(this).find('.total').text().replace(/\D/g, '').replace(' đ', '').trim());
        })
        $('#btnViewTotal').text(formatNumber(totalAll, '.', ',') + " đ");
    });

    $('#btnUpdate').click(function () {
        var listQuantity = $('.cls_quantity');
        var cartList = [];
        $.each(listQuantity, function (i, item) {
            cartList.push({
                Quantity: $(item).val(),
                Product: {
                    ID_Product: $(item).data('id')
                }
            });
        });

        $.ajax({
            url: '/Cart/Update',
            data: { cartModel: JSON.stringify(cartList) },
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/giohang";
                }
            }
        })
    });

    $('.btnDelete').click(function (e) {
        e.preventDefault();
        $.ajax({
            data: { id: $(this).data('id') },
            url: '/Cart/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/giohang";
                }
            }
        })
    });

    //$("#txtEmail").on('invalid', function (e) {
    //    if (e.target.validity.typeMismatch) {
    //        e.target.setCustomValidity("Email không đúng định dạng");
    //    }
    //});

    $('#btnSend').click(function () {
        var email = $('#txtEmail').val();
        var content = $('#txtContent').val();
        if (email == '' || content == '') {
            return;
        }

        var reg = /[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}/igm;
        if (!reg.test(email)) {
            return;
        }

        $.ajax({
            url: '/Feedback/Send',
            type: 'POST',
            dataType: 'json',
            data: {
                email: email,
                content: content
            },
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/lienhe";
                    resetForm();
                }
            }
        });
    });

    function resetForm() {
        $('#txtEmail').val('');
        $('#txtContent').val('');
    }

});