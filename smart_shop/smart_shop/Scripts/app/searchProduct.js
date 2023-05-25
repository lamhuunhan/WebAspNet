(function () {
    $("#sex__object").change(function () {
        //$('#categoryid').empty();
        $('#categoryid option').remove();

        var sex = $('#sex__object').val();
        if (sex === "") {
            return;
        }
        else {
            $.ajax({
                type: "Get",
                url: "/Search/getCategory",
                data: {
                    sex: sex
                },

                datatype: "Json",
                success: function (data) {
                    $('#categoryid').append("<option >--Chọn--</option>");
                    $.each(data, function (index, value) {
                      
                        $('#categoryid').append('<option name="categoryName" data-urlcategory="' + value.Url + '" value="' + value.MaLoaiSP + '">' + value.TenLoai + '</option>');
                    });
                }
            });
        }

    });
})();
(function () {
    $("#categoryid").change(function () {
        $('#productDetail').empty();
        var categoryid = $('#categoryid').val();
        if (categoryid === "") {
            return;
        }
        else {
            $.ajax({
                type: "Post",
                url: "/Search/getProductDetail",
                data: {
                    categoryid: categoryid
                },

                datatype: "Json",
                success: function (data) {
                    $.each(data, function (index, value) {
                        $('#productDetail').append('<option name="id" data-urlproduct="' + value.TenSanPham_KhongDau + '" value="' + value.MaSanPham + '">' + value.TenSanPham + '</option>');
                    });
                }
            });
        }

    });
})();
(function () {
    $(".btn__searchProuct").click(function () {
        var $selfCategory = $('#categoryid option:selected');
        var $selfProduct = $('#productDetail option:selected');
        var sex__text = $('#sex__object option:selected').text();
        var category__text = $selfCategory.data('urlcategory');
        var product__text = $selfProduct.data('urlproduct');
        var id = $selfProduct.val();

        if (sex__text === "--Chọn--" || typeof (category__text) === "undefined" || typeof (product__text) === "undefined") {
            toastr.warning("Vui lòng chọn thông tin !")
            return;
        }
        else {

            //var url = '/tim-kiem' + '/' + id + '/' + category__text + '/' + product__text + '.html';
            var url = "/tim-kiem/thoi-trang/" + sex__text + "/" + category__text + "/" + product__text + "/" + id + ".html";
            window.location.href = url;
        }


    });
})();

