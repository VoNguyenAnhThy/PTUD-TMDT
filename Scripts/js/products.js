let products = [
    {
        name: 'Mẫu thiết kế áo bóng đá SMD001',
        image1: '~/Content/images/Bóng đá 1.jpg',
        image2: '~/Content/images/Bóng đá 4.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng chuyền SMC001',
        image1: '~/Content/images/Bóng chuyền 1.jpg',
        image2: '~/Content/images/Bóng chuyền 4.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng rổ SMR001',
        image1: '~/Content/images/Bóng rổ 1.jpg',
        image2: '~/Content/images/Bóng rổ 2.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng chuyền SMC002',
        image1: '~/Content/images/Bóng chuyền 3.jpg',
        image2: '~/Content/images/Bóng chuyền 2.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo cầu lông SML001',
        image1: '~/Content/images/Cầu lông 1.jpg',
        image2: '~/Content/images/Cầu lông 2.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng đá SMD002',
        image1: '~/Content/images/Bóng đá 3.jpg',
        image2: '~/Content/images/Bóng đá 5.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng đá SMD003',
        image1: '~/Content/images/Bóng đá 6.jpg',
        image2: '~/Content/images/Bóng đá 7.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo bóng rổ SMR002',
        image1: '~/Content/images/Bóng rổ 4.jpg',
        image2: '~/Content/images/Bóng rổ 5.jpg',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
    {
        name: 'Mẫu thiết kế áo cầu lông SML002',
        image1: '~/Content/images/Cầu lông 4.png',
        image2: '~/Content/images/Cầu lông 3.png',
        old_price: '400.000đ',
        curr_price: '250.000đ'
    },
]

let product_list = document.querySelector('#products');

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
                            <a href="./product-detail.html" class="btn-flat btn-hover btn-shop-now">Xem ngay</a>
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

let filter_col = document.querySelector('#filter-col')

document.querySelector('#filter-toggle').addEventListener('click', () => filter_col.classList.toggle('active'))

document.querySelector('#filter-close').addEventListener('click', () => filter_col.classList.toggle('active'))
