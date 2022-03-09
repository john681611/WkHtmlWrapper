using System.IO;
using System.Threading.Tasks;
using WkHtmlWrapper.Image.Options;
using WkHtmlWrapper.Pdf.Options;

namespace WkHtmlWrapper.Converters.Interfaces
{
    public interface IHtmlConverter
    {
        Task<string> ToImageAsync(string html, string outputFile);

        Task<string> ToImageAsync(string html, string outputFile, GeneralImageOptions options);

        Task<string> ToImageAsync(Stream html, string outputFile);

        Task<string> ToImageAsync(Stream html, string outputFile, GeneralImageOptions options);

        Task<string> ToPdfAsync(string html, string outputFile);

        Task<string> ToPdfAsync(string html, string outputFile, GeneralPdfOptions options);

        Task<string> ToPdfAsync(Stream html, string outputFile);

        Task<string> ToPdfAsync(Stream html, string outputFile, GeneralPdfOptions options);
    }
}