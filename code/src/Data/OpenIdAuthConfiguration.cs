namespace OpenIdAuth.Data {
    public static class OpenIdAuthConfiguration {
        public static string GetConnectionString() {
            return Properties.Settings.Default.OpenIdAuthConnectionString;
        }

        public static int GetNumberOfImages()
        {
            return Properties.Settings.Default.NumberOfImagesForPassword;
        }
    }
}