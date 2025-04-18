using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GSM.DAO
{
    public class ShearchPostDAO
    {
        private static ShearchPostDAO instance;

        public static ShearchPostDAO Instance
        {
            get { if (instance == null) instance = new ShearchPostDAO(); return ShearchPostDAO.instance; }
            private set { ShearchPostDAO.instance = value; }
        }
        public string ShortenFacebookPostLink(string originalLink)
        {
            // Tìm vị trí của "?__" và "&__"
            if (string.IsNullOrEmpty(originalLink))
            {
                Console.WriteLine("⚠️ Link rỗng hoặc null.");
                return originalLink;
            }

            try
            {
                // Tìm chỉ số xuất hiện đầu tiên giữa ?__ và &__
                int indexQuestion = originalLink.IndexOf("?__");
                int indexAmp = originalLink.IndexOf("&__");

                int cutIndex = -1;

                if (indexQuestion != -1 && indexAmp != -1)
                {
                    cutIndex = Math.Min(indexQuestion, indexAmp);
                }
                else if (indexQuestion != -1)
                {
                    cutIndex = indexQuestion;
                }
                else if (indexAmp != -1)
                {
                    cutIndex = indexAmp;
                }

                // Cắt chuỗi tại vị trí sớm nhất nếu có
                if (cutIndex != -1)
                {
                    originalLink = originalLink.Substring(0, cutIndex);
                }

                // Thay thế domain Facebook về dạng rút gọn
                originalLink = originalLink.Replace("https://www.facebook.com/", "https://fb.com/");
                originalLink = originalLink.Replace("https://web.facebook.com/", "https://fb.com/");

                return originalLink;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi trong ShortenFacebookPostLink: " + ex.Message);
                return originalLink;
            }
        }
        public (string content, string originalContent) GetPostContent(IWebElement post)
        {
            try
            {
                // Tìm các phần tử nội dung
                var contentpost = post.FindElements(By.CssSelector("div[class='xdj266r x11i5rnm xat24cr x1mh8g0r x1vvkbs x126k92a']"));

                string content = "";
                string originalContent = "";
                if (contentpost.Count == 0)
                {
                    var bgContentElements = post.FindElements(By.CssSelector("div[class='xdj266r x11i5rnm xat24cr x1mh8g0r x1vvkbs']"));
                    if (bgContentElements.Count > 0)
                    {                      
                        foreach (var cont in bgContentElements)
                        {
                            content += cont.Text.Trim();
                        }
                    }                   
                }
                else
                {
                    if (contentpost.Count == 1)
                    {
                        if (contentpost[0].Text.IndexOf("Xem thêm") != -1)
                        {
                            try
                            {
                                // Tìm `div[role='button']` bên trong `span` đó
                                var seeMoreButton = contentpost[0].FindElement(By.CssSelector("div[role='button']"));
                                // Click để mở rộng nội dung
                                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", seeMoreButton);
                                Thread.Sleep(1000); // Đợi 1s trước khi click
                                seeMoreButton.Click();
                                Thread.Sleep(2000); // Chờ nội dung mở rộng
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi khi click 'Xem thêm': " + ex.Message);
                            }
                        }
                        content = contentpost[0].Text.Trim();
                    }
                    else if (contentpost.Count == 2)
                    {
                        if (contentpost[0].Text.IndexOf("Xem thêm") != -1)
                        {
                            try
                            {
                                // Tìm `div[role='button']` bên trong `span` đó
                                var seeMoreButton = contentpost[0].FindElement(By.CssSelector("div[role='button']"));
                                // Click để mở rộng nội dung
                                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", seeMoreButton);
                                Thread.Sleep(1000); // Đợi 1s trước khi click
                                seeMoreButton.Click();
                                Thread.Sleep(2000); // Chờ nội dung mở rộng
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi khi click 'Xem thêm': " + ex.Message);
                            }
                        }
                        content = contentpost[0].Text.Trim();
                        if (contentpost[1].Text.IndexOf("Xem thêm") != -1)
                        {
                            try
                            {
                                // Tìm `div[role='button']` bên trong `span` đó
                                var seeMoreButton = contentpost[1].FindElement(By.CssSelector("div[role='button']"));
                                // Click để mở rộng nội dung
                                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", seeMoreButton);
                                Thread.Sleep(1000); // Đợi 1s trước khi click
                                seeMoreButton.Click();
                                Thread.Sleep(2000); // Chờ nội dung mở rộng
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi khi click 'Xem thêm': " + ex.Message);
                            }
                        }
                        originalContent = contentpost[1].Text.Trim(); // Nội dung bài viết gốc
                    }

                }

                return (content, originalContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy nội dung bài viết: " + ex.Message);
                return ("", "");
            }
        }
        public (string commentCount, string shareCount) ExtractCommentAndShareCount(IWebElement post)
        {
            string commentCount = "0";
            string shareCount = "0";

            try
            {
                var elements = post.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"));

                foreach (var element in elements)
                {
                    string text = element.Text;

                    if (text.Contains("bình luận"))
                        commentCount = text;
                    else
                        shareCount = text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi lấy số bình luận hoặc chia sẻ bài viết: " + ex.Message);
            }

            return (commentCount, shareCount);
        }
        public bool SoSanhNoiDungTuyetDoi(List<string> keywordList, string content)
        {
            if (keywordList == null || string.IsNullOrWhiteSpace(content))
                return false;

            foreach (var keyword in keywordList)
            {
                string trimmedKeyword = keyword?.Trim();
                if (string.IsNullOrWhiteSpace(trimmedKeyword)) continue;

                // So sánh nguyên cụm, không phân biệt hoa thường
                if (content.IndexOf(trimmedKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
   

