namespace CleanArchMvc.Domain.Constants
{
    public class Constants
    {
        public static readonly string ERROR_INVALID_NAME = "Invalid name. Name is required.";
        public static readonly string ERROR_MINIMUM_CHAR_NAME = "Invalid name, too short, minimum 3 charecters.";

        public static readonly string ERROR_INVALID_DESCRIPTION = "Invalid description. Description is required.";
        public static readonly string ERROR_MINIMUM_CHAR_DESCRIPTION = "Invalid description, too short, minimum 5 charecters.";

        public static readonly string ERROR_MAXIMUM_CHAR_IMAGE = "Invalid image name, too long, maximum 250 charecters.";

        public static readonly string ERROR_MINIMUM_ID_VALUE = "Invalid Id value.";
        public static readonly string ERROR_MINIMUM_PRICE_VALUE = "Invalid price value.";
        public static readonly string ERROR_MINIMUM_STOCK_VALUE = "Invalid stock value.";

        public static readonly int MINIMUM_CHAR_NAME_VALUE = 3;
        public static readonly int MINIMUM_CHAR_DESCRIPTION_VALUE = 5;

        public static readonly int ZERO_VALUE = 0;

        public static readonly int MAXIMUM_CHAR_IMAGE_VALUE = 250;
    }
}
