// Lấy các phần tử HTML thông qua ID
const days = document.getElementById("days");
const hours = document.getElementById("hours");
const minutes = document.getElementById("minutes");
const seconds = document.getElementById("seconds");

// Lấy năm hiện tại
const currentYear = new Date().getFullYear();

// Thiết lập thời điểm kết thúc đếm ngược (ngày 25 tháng 12 năm 2023, 00:00:00)
const newYearTime = new Date("2023-12-25T00:00:00");

// Hàm cập nhật thời gian đếm ngược
function updateCountdown() {
    // Lấy thời gian hiện tại
    const currentTime = new Date();

    // Tính khoảng thời gian còn lại giữa thời điểm kết thúc và thời điểm hiện tại
    const diff = newYearTime - currentTime;

    // Tính số ngày, giờ, phút, giây
    const d = Math.floor(diff / 1000 / 60 / 60 / 24);
    const h = Math.floor(diff / 1000 / 60 / 60) % 24;
    const m = Math.floor(diff / 1000 / 60) % 60;
    const s = Math.floor(diff / 1000) % 60;

    // Cập nhật giá trị vào các phần tử HTML
    days.innerHTML = d;
    hours.innerHTML = h < 10 ? "0" + h : h;
    minutes.innerHTML = m < 10 ? "0" + m : m;
    seconds.innerHTML = s < 10 ? "0" + s : s;
}

// Gọi hàm updateCountdown mỗi giây
setInterval(updateCountdown, 1000);