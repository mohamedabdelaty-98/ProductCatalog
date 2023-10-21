let productcat = document.getElementById("productbycat");
let products = document.getElementById("products");

function AllProduct() {
    products.classList.remove("display_visable");
    productcat.classList.add("display_visable");
    console.log("any");
    $.ajax(
        {
            url: "/ProductUser/getall/",
            success: function (result) {
                console.log(result);
                $("#products").html(result);
            }
        }

    );
}
function displaybycategory(id) {
    products.classList.add("display_visable");
    productcat.classList.remove("display_visable");
    console.log("any");
    $.ajax(
        {
            url: "/ProductUser/getproductbycat/" +id,
            success: function (result) {
                console.log(result);
                $("#productbycat").html(result);
            }
        }

    );
}