$(document).ready(function () {

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
                    alert("Cập nhật giỏ hàng thành công !!!");
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

    //$('.btn-search').click(function () {
    //    var txtSearch = $('.txt-search').val();
    //    $.ajax({
    //        data: { txtSearch: txtSearch },
    //        url: '/Product/DetailProductByName',
    //        dataType: 'text',
    //        type: 'POST',
    //        success: function () {
                
    //        }
    //    })
    //});

    //$('.numberPage').click(function () {
    //    var numberPage = $(this).text();
    //    var category = $('#category-product').text();
    //    var trademark = $('#trademark-product').text();
    //    var categoryID = $('#category-product').data('id');
    //    var trademarkID = $('#trademark-product').data('id');
    //    if (trademarkID == null) {
    //        $.ajax({
    //            data: { id: categoryID, numberPage: numberPage },
    //            url: '/danhmuc/' + category + '/' + categoryID,
    //            dataType: 'json',
    //            type: 'POST',
    //            success: function () {
                    
    //            }
    //        })
    //    }
    //    else {
    //        $.ajax({
    //            data: { id: trademarkID, numberPage: numberPage },
    //            url: '/danhmuc/' + category + '/' + trademark + '/' + trademarkID,
    //            dataType: 'json',
    //            type: 'POST',
    //            success: function () {
                    
    //            }
    //        })
    //    }
    //});

    $('.btn-update-product').click(function () {
        alert("jahsjahjah");
        var name = $(this).closest('tr').find('.name-product').text();
        var quantity = $(this).closest('tr').find('.quantity-product').text();
        var price = $(this).closest('tr').find('.price-product').text();
        var trademark = $(this).closest('tr').find('.trademark-product').text();
        var id = $(this).closest('tr').find('.id-product').text();
        $('.form-product').find('#modal-name-product').val(name);
        $('.form-product').find('#modal-quantity-product').val(quantity);
        $('.form-product').find('#modal-trademark-product select').val(trademark);
        $('.form-product').find('#modal-price-product').val(price);
        $('.form-product').find('#modal-id-product').val(id);
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
                    window.location.href = "/";
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
});