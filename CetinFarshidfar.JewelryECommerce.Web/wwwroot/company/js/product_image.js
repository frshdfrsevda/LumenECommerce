$(document).ready(function () {
    // Dinamik olarak yüklenen 'update' ve 'delete' butonları için event delegation
    $(document).on('click', '.update-photo-btn', function () {
        var button = $(this);
        var photoId = button.data('id');
        var inputValue = $('input[data-id="input-' + photoId + '"]').val();

        // Spinner eklemek için butonun içeriğini değiştir
        button.html('<i class="fa fa-spinner fa-spin"></i>');

        $.ajax({
            url: '/Company/Products/UpdateImageQueue',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                Id: photoId,
                Queue: inputValue
            }),
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                } else {
                    alert(response.message);
                }
                button.html('<i class="fa-solid fa-wrench"></i>'); // İşlem tamamlandıktan sonra buton içeriğini geri yükle
            },
            error: function (error) {
                alert('Error updating photo.');
                button.html('<i class="fa-solid fa-wrench"></i>'); // Hata durumunda buton içeriğini geri yükle
            }
        });
    });

    $(document).on('click', '.delete-photo-btn', function () {
        var button = $(this);
        var photoId = button.data('id');

        // Spinner eklemek için butonun içeriğini değiştir
        button.html('<i class="fa fa-spinner fa-spin"></i>');

        $.ajax({
            url: '/Company/Products/DeleteProductImage',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                Id: photoId
            }),
            success: function (response) {
                alert('Photo deleted successfully!');
                button.closest('.row').remove(); // İlgili fotoğrafı DOM'dan kaldır
            },
            error: function (error) {
                alert('Error deleting photo.');
                button.html('<i class="fa-solid fa-trash-can"></i>'); // Hata durumunda buton içeriğini geri yükle
            }
        });
    });
});
