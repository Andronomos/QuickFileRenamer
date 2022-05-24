using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFileRenamer
{
    public class RenamerSettings
    {
        private const int _fileNameMaxLength = 7;


        public int NewFileNameLength => _fileNameMaxLength;

        public string WorkPath => Environment.CurrentDirectory;

        public char[] Characters => "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        public List<string> Extensions => new List<string> {
            ".jpg",
            ".jpeg",
            ".gif",
            ".png",
            ".bmp",
            ".mpeg",
            ".mpg",
            ".flv",
            ".avi",
            ".mp4",
            ".mov",
            ".wmv",
            ".3gp",
            ".rm",
            ".rmvb",
            ".m4v",
            ".mkv",
            ".divx",
            ".ts",
            ".webm",
            ".wav",
            ".mp3"
        };


    }
}
