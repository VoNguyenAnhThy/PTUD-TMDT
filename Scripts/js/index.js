let slide_index = 0
let slide_play = true
let slides = document.querySelectorAll('.slide')

hideAllSlide = () => {
    slides.forEach(e => {
        e.classList.remove('active')
    })
}

showSlide = () => {
    hideAllSlide()
    slides[slide_index].classList.add('active')
}

nextSlide = () => slide_index = slide_index + 1 === slides.length ? 0 : slide_index + 1

prevSlide = () => slide_index = slide_index - 1 < 0 ? slides.length - 1 : slide_index - 1

// pause slide when hover slider

document.querySelector('.slider').addEventListener('mouseover', () => slide_play = false)

// enable slide when mouse leave out slider
document.querySelector('.slider').addEventListener('mouseleave', () => slide_play = true)

// slider controll

document.querySelector('.slide-next').addEventListener('click', () => {
    nextSlide()
    showSlide()
})

document.querySelector('.slide-prev').addEventListener('click', () => {
    prevSlide()
    showSlide()
})

showSlide()

setInterval(() => {
    if (!slide_play) return
    nextSlide()
    showSlide()
 }, 3000);

// render products
let products = [
    {
        name: 'Mẫu thiết kế áo Tennis SMT001',
        image1: '~/Content/images1/Tennis 1.png',
        image2: '~/Content/images1/Tennis 1.1.png',
        old_price: '300.000 VND',
        curr_price: '250.000 VND'
    },
    {
        name: 'Mẫu thiết kế áo bóng chuyền SMC001 ',
        image1: '~/Content/images1/Bóng chuyền 1.jpg',
        image2: '~/Content/images1/Bóng chuyền 2.jpg',
        old_price: '300.000 VND',
        curr_price: '250.000 VND'
    },
    {
        name: 'Mẫu thiết kế áo bóng rổ SMR002 ',
        image1: '~/Content/images1/Bóng rổ 5.jpg',
        image2: '~/Content/images1/Bóng rổ 3.jpg',
        old_price: '300.000 VND',
        curr_price: '250.000 VND'
    },
    {
        name: 'Mẫu thiết kế áo Esport SME002 ',
        image1: '~/Content/images1/Esport 3.jpg',
        image2: '~/Content/images1/Esport 3.1.jpg',
        old_price: '300.000 VND',
        curr_price: '250.000 VND'
    },
    {
        name: 'Mẫu thiết kế áo bóng đá SMD003 ',
        image1: '~/Content/images1/Bóng đá 3.jpg',
        image2: '~/Content/images1/Bóng đá 5.jpg',
        old_price: '300.000 VND',
        curr_price: '250.000 VND'
    },
    {
        name: 'Mẫu thiết kế áo khoác Esport SME004',
        image1: '~/Content/images1/Esport 4.jpg',
        image2: '~/Content/images1/Esport 4.1.jpg',
        old_price: '450.000 VND',
        curr_price: '350.000 VND'
    },
    {
        name: 'Mẫu thiết kế áo Tennis SML004',
        image1: '~/Content/images1/Tennis 4.png',
        image2: '~/Content/images1/Tennis 4.1.png',
        old_price: '300.000 VND',
        curr_price: '250.000 VND'
    },
]

let product_list = document.querySelector('#latest-products')
let best_product_list = document.querySelector('#best-products')

products.forEach(e => {
    let prod = `
        <div class="col-3 col-md-6 col-sm-12">
            <div class="product-card">
                <div class="product-card-img">
                    <img src="${e.image1}" alt="">
                    <img src="${e.image2}" alt="">
                </div>
                <div class="product-card-info">
                    <div class="product-btn">
                        <button class="btn-flat btn-hover btn-shop-now">xem ngay</button>
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
    best_product_list.insertAdjacentHTML("afterbegin", prod)
})


