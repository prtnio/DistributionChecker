using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace HCGStudio.DistributionChecker
{
    /// <summary>
    ///     Linux distribution details got from /etc/os-release
    /// </summary>
    [SupportedOSPlatform("linux")]
    public record LinuxDistribution
    {
        private readonly Dictionary<string, string>? _raw;

        /// <summary>
        /// Create an empty linux distribution record.
        /// </summary>
        public LinuxDistribution()
        {
        }

        /// <summary>
        /// Create an empty linux distribution record with original dictionary. 
        /// </summary>
        /// <param name="raw">Original dictionary.</param>
        public LinuxDistribution(Dictionary<string, string>? raw)
        {
            _raw = raw;
        }

        /// <summary>
        ///     A string identifying the operating system, without a version
        ///     component, and suitable for presentation to the user.
        /// </summary>
        public string? Name { get; init; }

        /// <summary>
        ///     A pretty operating system name in a format suitable for
        ///     presentation to the user.
        /// </summary>
        public string? PrettyName { get; init; }

        /// <summary>
        ///     A string identifying the operating system version,
        ///     excluding any OS name information, possibly including a
        ///     release code name, and suitable for presentation to the user.
        /// </summary>
        public string? Version { get; init; }

        /// <summary>
        ///     A lower-case string (mostly numeric, no spaces or other
        ///     characters outside of 0–9, a–z, ".", "_" and "-") identifying
        ///     the operating system version, excluding any OS name information
        ///     or release code name, and suitable for processing by scripts
        ///     or usage in generated filenames.
        /// </summary>
        public Version? VersionId { get; init; }

        /// <summary>
        ///     A lower-case string (no spaces or other characters outside
        ///     of 0–9, a–z, ".", "_" and "-") identifying the operating
        ///     system release code name, excluding any OS name information
        ///     or release version, and suitable for processing by scripts
        ///     or usage in generated filenames. This field is optional and
        ///     may not be implemented on all systems.
        /// </summary>
        public string? VersionCodeName { get; init; }

        /// <summary>
        ///     A lower-case string (no spaces or other characters outside
        ///     of 0–9, a–z, ".", "_" and "-") identifying the operating
        ///     system, excluding any version information and suitable for
        ///     processing by scripts or usage in generated filenames.
        /// </summary>
        public string? Id { get; init; }

        /// <summary>
        ///     A space-separated list of operating system identifiers in
        ///     the same syntax as the ID= setting. It should list identifiers
        ///     of operating systems that are closely related to the local
        ///     operating system in regards to packaging and programming
        ///     interfaces, for example listing one or more OS identifiers
        ///     the local OS is a derivative from. An OS should generally
        ///     only list other OS identifiers it itself is a derivative of,
        ///     and not any OSes that are derived from it, though symmetric
        ///     relationships are possible.
        /// </summary>
        public string[] IdLike { get; init; } = Array.Empty<string>();

        /// <summary>
        ///     A string uniquely identifying the system image used as the
        ///     origin for a distribution (it is not updated with system updates).
        /// </summary>
        public string? BuildId { get; init; }

        /// <summary>
        ///     A CPE name for the operating system, in URI binding syntax,
        ///     following the Common Platform Enumeration Specification as proposed by the NIST.
        /// </summary>
        public string? CpeName { get; init; }

        /// <summary>
        ///     A suggested presentation color when showing the OS name on the console.
        /// </summary>
        public string? AnsiColor { get; init; }

        /// <summary>
        ///     Should refer to the homepage of the operating system,
        ///     or alternatively some homepage of the specific
        ///     version of the operating system.
        /// </summary>
        public string? HomeUrl { get; init; }

        /// <summary>
        ///     Should refer to the main documentation page for this operating system.
        /// </summary>
        public string? DocumentationUrl { get; init; }

        /// <summary>
        ///     Should refer to the main support page for the operating system,
        ///     if there is any. This is primarily intended for operating systems
        ///     which vendors provide support for.
        /// </summary>
        public string? SupportUrl { get; init; }

        /// <summary>
        ///     Should refer to the main bug reporting page for the operating system,
        ///     if there is any. This is primarily intended for operating systems that
        ///     rely on community QA.
        /// </summary>
        public string? BugReportUrl { get; init; }

        /// <summary>
        ///     Should refer to the main privacy policy page for the operating system,
        ///     if there is any. These settings are optional, and providing only some
        ///     of these settings is common.
        /// </summary>
        public string? PrivacyPolicyUrl { get; init; }

        /// <summary>
        ///     A string, specifying the name of an icon as defined by freedesktop.org
        ///     Icon Theme Specification. This can be used by graphical applications
        ///     to display an operating system's or distributor's logo.
        /// </summary>
        public string? Logo { get; init; }

        /// <summary>
        ///     A string identifying a specific variant or edition of the operating
        ///     system suitable for presentation to the user. This field may be used
        ///     to inform the user that the configuration of this system is subject
        ///     to a specific divergent set of rules or default configuration settings.
        /// </summary>
        public string? Variant { get; init; }

        /// <summary>
        ///     A lower-case string (no spaces or other characters outside of 0–9,
        ///     a–z, ".", "_" and "-"), identifying a specific variant or edition
        ///     of the operating system.
        /// </summary>
        public string? VariantId { get; init; }

        /// <summary>
        ///     Get the raw content in the /etc/os-release file.
        /// </summary>
        /// <param name="key">Key of the content.</param>
        /// <returns>Content, <c>null</c>if not keepRawDictionary when cast.</returns>
        public string? this[string key] => _raw?[key];

        /// <summary>
        ///     Try to get the raw content in the /etc/os-release file.
        /// </summary>
        /// <param name="key">Key of the content.</param>
        /// <param name="content">Content, <c>null</c> if not found.</param>
        /// <returns>
        ///     <c>true</c> if content fount, <c>false</c> if not found or
        ///     keepRawDictionary was not set when cast.
        /// </returns>
        public bool TryGet(string key, out string? content)
        {
            content = null;
            return _raw?.TryGetValue(key, out content) ?? false;
        }
    }
}