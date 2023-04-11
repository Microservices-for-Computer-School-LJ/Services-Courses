using Courses.API.Data.Dtos;

namespace Courses.API.Business;

public static class DefaultResponseBusiness
{
    public static ApiResponseDto<string> SendDefaultApiEndpointOutput()
    {
        return ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint");
    }

    public static ApiResponseDto<string> SendDefaultApiEndpointV1Output()
    {
        return ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint V1");
    }
}

