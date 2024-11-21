using DialCMS.Application.Commands.CreateContentType;
using DialCMS.Application.Dtos;
using DialCMS.Domain.Entities;

namespace DialCMS.Application.Extensions;

public static class FieldExtensions
{
    public static Field ToField(this FieldDto fieldDto)
    {
        if (fieldDto == null)
        {
            throw new ArgumentNullException(nameof(fieldDto));
        }

        return new Field(fieldDto.Name, fieldDto.DataType);
    }

    public static List<Field> ToFields(this IEnumerable<FieldDto> fieldDtos)
    {
        if (fieldDtos == null)
        {
            throw new ArgumentNullException(nameof(fieldDtos));
        }

        return fieldDtos.Select(dto => dto.ToField()).ToList();
    }
}