namespace ZoneLogin.Controls;

public partial class CustomEntry : ContentView
{
    public CustomEntry()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomEntry), string.Empty);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(CustomEntry), string.Empty);
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomEntry), string.Empty);
    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(CustomEntry), false);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(CustomEntry), false);
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty IsPasswordVisibleProperty = BindableProperty.Create(nameof(IsPasswordVisible), typeof(bool), typeof(CustomEntry), true);
    public bool IsPasswordVisible
    {
        get => (bool)GetValue(IsPasswordVisibleProperty);
        set => SetValue(IsPasswordVisibleProperty, value);
    }

    public static readonly BindableProperty PasswordStrengthTextProperty = BindableProperty.Create(nameof(PasswordStrengthText), typeof(string), typeof(CustomEntry), string.Empty);
    public string PasswordStrengthText
    {
        get => (string)GetValue(PasswordStrengthTextProperty);
        set => SetValue(PasswordStrengthTextProperty, value);
    }

    public static readonly BindableProperty HasPasswordStrengthProperty = BindableProperty.Create(nameof(HasPasswordStrength), typeof(bool), typeof(CustomEntry), false);
    public bool HasPasswordStrength
    {
        get => (bool)GetValue(HasPasswordStrengthProperty);
        set => SetValue(HasPasswordStrengthProperty, value);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        IsPasswordVisible = !IsPasswordVisible;
        entry.IsPassword = !IsPasswordVisible;
    }

    private void entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (IsPassword)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                var passwordStrengthText = string.Empty;
                var textColor = Colors.Green;

                if (e.NewTextValue.Length < 5)
                {
                    passwordStrengthText = "Very Weak";
                    textColor = Colors.Green;
                    IsValid = false;
                }
                else if (e.NewTextValue.Length <= 7)
                {
                    passwordStrengthText = "Medium Strength";
                    textColor = Colors.Orange;
                    IsValid = false;
                }
                else if (e.NewTextValue.Length > 7)
                {
                    passwordStrengthText = "Very Strong!";
                    textColor = Colors.Red;
                    IsValid = true;
                }

                StrengthLabel.Text = passwordStrengthText;
                StrengthLabel.TextColor = textColor;
            }
            else
            {
                StrengthLabel.Text = string.Empty;
                IsValid = false;
            }
        }
    }
}