using DialCMS.Domain.Core;

namespace DialCMS.Domain.ValueObjects;

public class ImageGalleryFieldValue: ValueObject
{
    private readonly List<ImageFieldValue> _images;
    public IReadOnlyCollection<ImageFieldValue> Images => _images.AsReadOnly();

    public int MaxImages { get; private set; }

    public ImageGalleryFieldValue(int maxImages = 10)
    {
        if (maxImages <= 0)
            throw new ArgumentException("Max images must be greater than zero.", nameof(maxImages));

        MaxImages = maxImages;
        _images = new List<ImageFieldValue>();
    }

    public void AddImage(ImageFieldValue image)
    {
        if (_images.Count >= MaxImages)
            throw new InvalidOperationException($"Cannot add more than {MaxImages} images.");

        _images.Add(image);
    }

    public override string ToString() => $"Gallery with {_images.Count} images.";
}