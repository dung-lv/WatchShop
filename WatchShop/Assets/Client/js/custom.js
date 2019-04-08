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
});