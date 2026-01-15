# Safari Reborn

Safari Reborn là một dự án **trình duyệt web mini** được xây dựng bằng **C# WinForms** và **WebView2**.  
Mục tiêu là tái tạo giao diện và trải nghiệm giống với **Safari** trên macOS, với phong cách **tối giản, hiện đại, dark mode**.

---

## Tính năng chính

- **Thanh công cụ trên cùng**:
  - Nút **Back**, **Forward**, **Reload**.
  - **URL bar** bo tròn, hỗ trợ nhập địa chỉ và tìm kiếm.
  - **Progress bar mảnh** hiển thị trạng thái tải trang.

- **WebView2 tích hợp**:
  - Hiển thị nội dung web hiện đại, hỗ trợ HTML5, CSS3, JavaScript.
  - Tự động cập nhật URL bar và tiêu đề Form khi điều hướng.

- **Dark Mode**:
  - Giao diện nền tối, icon đơn sắc, trải nghiệm giống Safari Dark Mode.

---

## Công nghệ sử dụng

- **C# WinForms (.NET 8)**
- **Microsoft.Web.WebView2** (NuGet package)
- **Custom UI** với Panel, Button, TextBox, ProgressBar