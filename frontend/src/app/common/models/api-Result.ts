import { ApiResultStatusCode } from "./api-result-status-code";

export interface ApiResult {
    isSuccess: boolean;
    apiStatusCode: ApiResultStatusCode;
    apiStatusCodeDescrption: string;
    messages: { [key: string]: string[]; } | null;
    data: any;
}