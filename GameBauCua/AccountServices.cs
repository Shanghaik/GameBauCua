using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBauCua
{
    internal class AccountServices
    {
        public static List<Account> GetAllAccounts()
        {
            // Đọc tất cả các dòng trong file txt ra 1 mảng
            string[] allLines = File.ReadAllLines("account.txt");
            // Tạo 1 List để chứa các Account hợp lệ có cấu trúc username|password|money
            List<Account> accounts = new List<Account>();
            foreach (string line in allLines) // check từng dòng trả về từ file
            {
                if (line.Split("|").Length == 3 && line.Trim().Length > 0)
                {
                    string[] arr = line.Split("|");
                    if (arr[0].Trim().Length * arr[1].Trim().Length * arr[2].Trim().Length == 0) continue;
                    else // Nếu không có thuộc tính nào bị rỗng (Bài này tạm hiểu là data sẽ đúng)
                    {
                        Account ac = new Account()
                        {
                            Username = arr[0].Trim(),
                            Password = arr[1].Trim(),
                            Money = Convert.ToInt32(arr[2].Trim())
                        };
                        accounts.Add(ac);
                    }
                }
            }
            return accounts;
        }
        public static Account CheckAccount(string username, string password)
        {
            foreach (var item in GetAllAccounts())
            {
                if (item.Password == password && item.Username == username) return item;
            }
            return null;
        }

        public static void SavePlayData(string username, int money)
        {
            // Lấy List account ra để check và sửa tài khaonr trùng với username truyền vào
            List<Account> accounts = GetAllAccounts(); // Lấy ra bằng cách getall
            foreach (var account in accounts) // Kiểm tra từng acccount trong danh sách vừa lấy
            {
                if (account.Username == username) // Khi username trùng thì update tiền
                {
                    account.Money = money;
                    break;
                }
            }
            List<string> allAccounts = new List<string>(); // Tạo 1 list để lưu vào file
            // Lưu cả List vào file
            foreach (var item in accounts) // Tạo ra các dòng cho data
            {
                string accountData = $"{item.Username}|{item.Password}|{item.Money}";
                // Tạo ra các Line với format chuẩn username|password|money
                allAccounts.Add(accountData); // Add các dòng vừa tạo vào List để ghi đề vào file txt
            }
            // Xóa dữ liệu gốc trong file bằng cách ghi đè 1 chuỗi rỗng
            // Thêm dữ liệu từ data vừa tạo ra vào file bằng cách ghi đè
            File.WriteAllLines("account.txt", allAccounts); // Ghi đè dữ liệu vừa thua được vào file
        }

    }
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }
    }
}
