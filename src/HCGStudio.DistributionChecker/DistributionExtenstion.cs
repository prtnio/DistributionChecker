using System.Linq;
using System.Runtime.Versioning;

namespace HCGStudio.DistributionChecker
{
    /// <summary>
    /// Extenstion of Linux Distribution
    /// </summary>
    public static class DistributionExtenstion
    {
        #region Is

        /// <summary>
        ///     Check if the distribution is ArchLinux.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is ArchLinux.</returns>
        public static bool IsArchLinux(this LinuxDistribution distribution)
        {
            return distribution.Id == "arch";
        }

        /// <summary>
        ///     Check if the distribution is CentOS.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is CentOS.</returns>
        public static bool IsCentOS(this LinuxDistribution distribution)
        {
            return distribution.Id == "centos";
        }

        /// <summary>
        ///     Check if the distribution is Fedora.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is Fedora.</returns>
        public static bool IsFedora(this LinuxDistribution distribution)
        {
            return distribution.Id == "fedora";
        }

        /// <summary>
        ///     Check if the distribution is RHEL.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is RHEL.</returns>
        public static bool IsRedHat(this LinuxDistribution distribution)
        {
            return distribution.Id == "rhel";
        }

        /// <summary>
        ///     Check if the distribution is Ubuntu.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is Ubuntu.</returns>
        public static bool IsUbuntu(this LinuxDistribution distribution)
        {
            return distribution.Id == "ubuntu";
        }

        /// <summary>
        ///     Check if the distribution is Debian.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is Debian.</returns>
        public static bool IsDebian(this LinuxDistribution distribution)
        {
            return distribution.Id == "debian";
        }

        /// <summary>
        ///     Check if the distribution is Alpine Linux.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is Alpine Linux.</returns>
        public static bool IsAlpine(this LinuxDistribution distribution)
        {
            return distribution.Id == "alpine";
        }

        /// <summary>
        ///     Check if the distribution is the required distribution.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <param name="distributionName">Id name of the distribution.</param>
        /// <returns>True if the distribution is the required distribution.</returns>
        public static bool Is(this LinuxDistribution distribution, string distributionName)
        {
            return distribution.Id == distributionName;
        }

        #endregion

        #region IsLike

        /// <summary>
        ///     Check if the distribution is like ArchLinux.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is like ArchLinux.</returns>
        public static bool IsLikeArchLinux(this LinuxDistribution distribution)
        {
            return distribution.IdLike.Contains("arch");
        }

        /// <summary>
        ///     Check if the distribution is like CentOS.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is like CentOS.</returns>
        public static bool IsLikeCentOS(this LinuxDistribution distribution)
        {
            return distribution.IdLike.Contains("centos");
        }

        /// <summary>
        ///     Check if the distribution is like RHEL.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is like RHEL.</returns>
        public static bool IsLikeRedHat(this LinuxDistribution distribution)
        {
            return distribution.IdLike.Contains("rhel");
        }

        /// <summary>
        ///     Check if the distribution is like Fedora.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is like Fedora.</returns>
        public static bool IsLikeFedora(this LinuxDistribution distribution)
        {
            return distribution.IdLike.Contains("fedora");
        }

        /// <summary>
        ///     Check if the distribution is like Ubuntu.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is like Ubuntu.</returns>
        public static bool IsLikeUbuntu(this LinuxDistribution distribution)
        {
            return distribution.IdLike.Contains("ubuntu");
        }

        /// <summary>
        ///     Check if the distribution is like Debian.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is like Debian.</returns>
        public static bool IsLikeDebian(this LinuxDistribution distribution)
        {
            return distribution.IdLike.Contains("debian");
        }

        /// <summary>
        ///     Check if the distribution is like Alpine Linux.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is like Alpine Linux.</returns>
        public static bool IsLikeAlpine(this LinuxDistribution distribution)
        {
            return distribution.IdLike.Contains("alpine");
        }

        /// <summary>
        ///     Check if the distribution is like the required distribution.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <param name="distributionName">Id name of the distribution.</param>
        /// <returns>True if the distribution is like the required distribution.</returns>
        public static bool IsLike(this LinuxDistribution distribution, string distributionName)
        {
            return distribution.IdLike.Contains(distributionName);
        }

        #endregion

        #region IsOrLike

        /// <summary>
        ///     Check if the distribution is or like ArchLinux.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is or like ArchLinux.</returns>
        public static bool IsOrLikeArchLinux(this LinuxDistribution distribution)
        {
            return distribution.IsArchLinux() || distribution.IsLikeArchLinux();
        }

        /// <summary>
        ///     Check if the distribution is or like CentOS.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is or like CentOS.</returns>
        public static bool IsOrLikeCentOS(this LinuxDistribution distribution)
        {
            return distribution.IsCentOS() || distribution.IsLikeCentOS();
        }

        /// <summary>
        ///     Check if the distribution is or like RHEL.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is or like RHEL.</returns>
        public static bool IsOrLikeRedHat(this LinuxDistribution distribution)
        {
            return distribution.IsRedHat() || distribution.IsLikeRedHat();
        }

        /// <summary>
        ///     Check if the distribution is or like Fedora.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is or like Fedora.</returns>
        public static bool IsOrLikeFedora(this LinuxDistribution distribution)
        {
            return distribution.IsFedora() || distribution.IsLikeFedora();
        }

        /// <summary>
        ///     Check if the distribution is or like Ubuntu.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is or like Ubuntu.</returns>
        public static bool IsOrLikeUbuntu(this LinuxDistribution distribution)
        {
            return distribution.IsUbuntu() || distribution.IsLikeUbuntu();
        }

        /// <summary>
        ///     Check if the distribution is or like Debian.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is or like Debian.</returns>
        public static bool IsOrLikeDebian(this LinuxDistribution distribution)
        {
            return distribution.IsDebian() || distribution.IsLikeDebian();
        }

        /// <summary>
        ///     Check if the distribution is or like Alpine Linux.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <returns>True if the distribution is or like Alpine Linux.</returns>
        public static bool IsOrLikeAlpine(this LinuxDistribution distribution)
        {
            return distribution.IsAlpine() || distribution.IsLikeAlpine();
        }

        /// <summary>
        ///     Check if the distribution is or like the required distribution.
        /// </summary>
        /// <param name="distribution">Distribution to check.</param>
        /// <param name="distributionName">Id name of the distribution.</param>
        /// <returns>True if the distribution is or like the required distribution.</returns>
        public static bool IsOrLike(this LinuxDistribution distribution, string distributionName)
        {
            return distribution.Is(distributionName) || distribution.IsLike(distributionName);
        }

        #endregion
    }
}