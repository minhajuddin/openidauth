namespace OpenIdAuth.Core.Configuration {
    public static class Config {
        public static string GetConnectionString() {
            return Properties.Settings.Default.OpenIdAuthConnectionString;
        }

        public static int GetNumberOfImages() {
            return Properties.Settings.Default.NumberOfImagesForPassword;
        }
    }
}