<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallApiWithDb.aspx.cs" Inherits="MyAPIHelloworldApp.CallApiWithDb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
     <div>
        <h2>All Products</h2>
        <ul id="products"/>
    </div>
     <div>
        <h2>Search by ID</h2>
        <input type="text" id="prodId" size="5"/>
        <input type="button" id="Search" value="Search" onlick="find();"/>
        <p id="product"/>
    </div>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
    <script>
            var uri = 'api/productsWithDB';
    $(document).ready(function(){
        //send an AJAX request
        $.getJSON(uri)
            .done(function (data) {
                //On success, data contains a list of products
                $.each(data, function (key, item) {
                    // add a lst item for the product
                    $('<li>', { text: formatItem(item) }).appendTo($('#products'));
                });
            });
    });

    $(document).on('click','#Search', function()
{
        alert("Dynamic button action");
         var id = $('#prodId').val();
        alert('this is find function for id :' + id);
        $.getJSON(uri + '/' + id)
            .done(function (data) {
                $('#product').text(formatItem(data));
            })
            .fail(function (jqXHR, textStatus, err) {
                $('#product').text('Error: No item found with id '+ err);
            });
});
    function formatItem(item) {
        return item.Name + ':$' + item.Price;
            }

    function find() {
        alert('test**');
        var id = $('#prodId').val();
        alert('this is find function for id :' + id);
        $.getJSON(uri + '/' + id)
            .done(function (data) {
                $('#product').text(formatItem(data));
            })
            .fail(function (jqXHR, textStatus, err) {
                $('#product').text('Erro:' + err);
            });
    }
    </script>
</body>
</html>
