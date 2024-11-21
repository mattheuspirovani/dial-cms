namespace DialCMS.Domain.ValueObjects;

public class ImageFieldValue
{
    public string Url { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public string AltText { get; private set; }

    public ImageFieldValue(string url, int width, int height, string altText = "")
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("Image URL cannot be null or empty.", nameof(url));

        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            throw new ArgumentException("Invalid image URL.", nameof(url));

        if (width <= 0)
            throw new ArgumentException("Image width must be positive.", nameof(width));

        if (height <= 0)
            throw new ArgumentException("Image height must be positive.", nameof(height));

        Url = url;
        Width = width;
        Height = height;
        AltText = altText ?? string.Empty;
    }

    public override string ToString() => $"{Url} ({Width}x{Height})";
}