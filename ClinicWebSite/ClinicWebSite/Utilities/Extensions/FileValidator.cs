using ClinicWebSite.Utilities.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClinicWebSite.Utilities.Extensions
{
    public static class FileValidator
    {
        public static bool ValidateType(this IFormFile file, string type)
        {
            if(file.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateSize(this IFormFile file, FileSize fileSize, int size)
        {
            switch (fileSize)
            {
                case FileSize.KB:
                    return file.Length <= size * 1024;
                case FileSize.MB:
                    return file.Length <= size * 1024 * 1024;
                case FileSize.GB:
                    return file.Length <= size * 1024 * 1024 * 1024;
            }
            return false;
        }

        public static async Task<string> CreateFileAsync(this IFormFile file, params string[] roots)
        {
            string path = string.Empty;

            string fileName = string.Concat(Guid.NewGuid().ToString(), file.FileName.Substring(file.FileName.LastIndexOf('.')));

            for(int i=0; i<roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }

            path = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public static void DeleteFile(this string file, params string[] roots)
        {
            string path = string.Empty;

            for(int i=0; i<roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }

            path = Path.Combine(path, file);

            if(File.Exists(path))
            {
                File.Delete(path);
            }

        }
    }
}
