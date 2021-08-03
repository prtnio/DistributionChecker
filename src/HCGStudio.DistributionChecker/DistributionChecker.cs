using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HCGStudio.DistributionChecker
{
    /// <summary>
    /// Checker to check linux distribution.
    /// </summary>
    public class DistributionChecker
    {
        private readonly Dictionary<string, string> _informationDictionary = new();

        /// <summary>
        ///     Create a new instance to read the information of Distribution.
        /// </summary>
        public DistributionChecker()
        {
            if (!OperatingSystem.IsLinux())
                throw new PlatformNotSupportedException();

            using var file = File.OpenRead("/etc/os-release");
            var status = 0;
            var sb = new StringBuilder();
            var name = string.Empty;
            var content = string.Empty;
            //NFA
            for (var c = file.ReadByte(); c != -1; c = file.ReadByte())
            {
                //We are very sure that /etc/os-release contains no non ASCII char.
                var b = (char) c;
                switch (status)
                {
                    case 0:
                    {
                        if (char.IsLetterOrDigit(b) || b == '_')
                        {
                            sb.Append(b);
                        }
                        else if (b == '=')
                        {
                            name = sb.ToString();
                            sb.Clear();
                            status = 1;
                        }
                        else
                        {
                            throw new FormatException();
                        }

                        break;
                    }
                    case 1:
                    {
                        if (b == '"')
                        {
                            status = 2;
                        }
                        else if (!char.IsControl(b))
                        {
                            sb.Append(b);
                            status = 4;
                        }
                        else
                        {
                            throw new FormatException();
                        }

                        break;
                    }
                    case 2:
                    {
                        if (b == '"')
                        {
                            content = sb.ToString();
                            sb.Clear();
                            status = 3;
                        }
                        else if (!char.IsControl(b))
                        {
                            sb.Append(b);
                        }
                        else
                        {
                            throw new FormatException();
                        }

                        break;
                    }
                    case 3:
                    {
                        if (b != '\n')
                            throw new FormatException();
                        _informationDictionary.Add(name, content);
                        status = 0;
                        break;
                    }
                    case 4:
                    {
                        if (!char.IsControl(b))
                        {
                            sb.Append(b);
                        }
                        else if (b == '\n')
                        {
                            content = sb.ToString();
                            sb.Clear();
                            _informationDictionary.Add(name, content);
                            status = 0;
                        }
                        else
                        {
                            throw new FormatException();
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Get information of your distribution.
        /// </summary>
        /// <param name="keepRawDictionary">Weather to keep the information of original file.</param>
        /// <returns>Distribution information.</returns>
        public LinuxDistribution GetDistribution(bool keepRawDictionary = false)
        {
            _informationDictionary.TryGetValue("NAME", out var name);
            _informationDictionary.TryGetValue("VERSION", out var version);
            _informationDictionary.TryGetValue("ID", out var id);
            _informationDictionary.TryGetValue("ID_LIKE", out var idLike);
            _informationDictionary.TryGetValue("VERSION_CODENAME", out var versionCodename);
            _informationDictionary.TryGetValue("VERSION_ID", out var versionId);
            Version.TryParse(versionId, out var castVersion);
            _informationDictionary.TryGetValue("PRETTY_NAME", out var prettyName);
            _informationDictionary.TryGetValue("ANSI_COLOR", out var ansiColor);
            _informationDictionary.TryGetValue("CPE_NAME", out var cpeName);
            _informationDictionary.TryGetValue("HOME_URL", out var homeUrl);
            _informationDictionary.TryGetValue("DOCUMENTATION_URL", out var documentationUrl);
            _informationDictionary.TryGetValue("SUPPORT_URL", out var supportUrl);
            _informationDictionary.TryGetValue("BUG_REPORT_URL", out var bugReportUrl);
            _informationDictionary.TryGetValue("PRIVACY_POLICY_URL", out var privacyPolicyUrl);
            _informationDictionary.TryGetValue("BUILD_ID", out var buildId);
            _informationDictionary.TryGetValue("VARIANT", out var variant);
            _informationDictionary.TryGetValue("VARIANT_ID", out var variantId);
            _informationDictionary.TryGetValue("LOGO", out var logo);

            return new(keepRawDictionary ? _informationDictionary : null)
            {
                Name = name,
                Version = version,
                Id = id,
                IdLike = idLike?.Split(" ") ?? Array.Empty<string>(),
                VersionCodeName = versionCodename,
                VersionId = castVersion,
                PrettyName = prettyName,
                AnsiColor = ansiColor,
                CpeName = cpeName,
                HomeUrl = homeUrl,
                DocumentationUrl = documentationUrl,
                SupportUrl = supportUrl,
                BugReportUrl = bugReportUrl,
                PrivacyPolicyUrl = privacyPolicyUrl,
                BuildId = buildId,
                Variant = variant,
                VariantId = variantId,
                Logo = logo
            };
        }
    }
}