document.querySelectorAll('.product-img-item').forEach(e => {
    e.addEventListener('click', () => {
        let img = e.querySelector('img').getAttribute('src')
        document.querySelector('#product-img > img').setAttribute('src', img)
    })
})

document.querySelector('#view-all-description').addEventListener('click', () => {
    let content = document.querySelector('.product-detail-description-content')
    content.classList.toggle('active')
    document.querySelector('#view-all-description').innerHTML = content.classList.contains('active') ? 'view less' : 'view all'
})

let products = [
    {
        name: 'Mẫu thiết kế áo bóng đá SMD002',
        image1: './images/Bóng đá 3.jpg',
        image2: './images/Bóng đá 5.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng đá SMD001',
        image1: './images/Bóng đá 4.jpg',
        image2: './images/Bóng đá 1.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng đá SMD003',
        image1: './images/Bóng đá 6.jpg',
        image2: './images/Bóng đá 7.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
]

let product_list = document.querySelector('#related-products')

renderProducts = (products) => {
    products.forEach(e => {
        let prod = `
            <div class="col-4 col-md-6 col-sm-12">
                <div class="product-card">
                    <div class="product-card-img">
                        <img src="${e.image1}" alt="">
                        <img src="${e.image2}" alt="">
                    </div>
                    <div class="product-card-info">
                        <div class="product-btn">
                            <a href="./product-detail.html" class="btn-flat btn-hover btn-shop-now">shop now</a>
                            <button class="btn-flat btn-hover btn-cart-add">
                                <i class='bx bxs-cart-add'></i>
                            </button>
                            <button class="btn-flat btn-hover btn-cart-add">
                                <i class='bx bxs-heart'></i>
                            </button>
                        </div>
                        <div class="product-card-name">
                            ${e.name}
                        </div>
                        <div class="product-card-price">
                            <span><del>${e.old_price}</del></span>
                            <span class="curr-price">${e.curr_price}</span>
                        </div>
                    </div>
                </div>
            </div>
        `
        product_list.insertAdjacentHTML("beforeend", prod)
    })
}

renderProducts(products)
