$(document).ready(function () {
    // Address-card tıklama olayını yönetme
    $('body').on('click', '.address-card', function () {
        var addressId = $(this).data('id');
        $('.thanks').show();
        $('#addressFormArea').show();
        $.ajax({
            url: `/Customer/User/AddressForm?addressId=${addressId}`,
            method: 'GET',
            success: function (html) {
                $('#addressFormArea').html(html);
                $('.thanks').hide();
            },
            error: function () {
                console.error('Hata oluştu');
                $('.thanks').hide();
            }
        });
    });

    // Movebtnre butonuna tıklama olayını yönetme
    $('body').on('click', '.movebtnre', function () {
        var addressId = $(this).data('id');
        $('.thanks').show();
        $.ajax({
            url: '/Customer/User/DeleteAddress',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ Id: addressId }),
            success: function (html) {
                $('#addressFormArea').empty().hide();
                // 3 saniye bekledikten sonra sayfayı yenile
                setTimeout(function () {
                    location.reload();
                }, 2000);
            },
            error: function () {
                console.error('Hata oluştu');
                $('.thanks').hide();
            }
        });
    });

    // Movebtnca butonuna tıklama olayını yönetme
    $('body').on('click', '.movebtnca', function () {
        $('#addressFormArea').empty().hide();
    });
});