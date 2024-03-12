using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validations;

public static class PasswordValidation
{
    public static bool IsValid(string password)
    {
        // Перевірка чи пароль не є порожнім або null
        if (string.IsNullOrEmpty(password))
            return false;

        // Перевірка чи пароль має мінімальну довжину
        const int minPasswordLength = 8;
        if (password.Length < minPasswordLength)
            return false;

        // Додаткові перевірки, які можна додати в майбутньому
        // Наприклад, чи є пароль достатньо складним (містить цифри, символи, рядкові символи тощо)

        // Якщо всі перевірки пройшли успішно, повертаємо true
        return true;
    }
}