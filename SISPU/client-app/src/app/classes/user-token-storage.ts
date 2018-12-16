export class UserTokenStorage {
    private static readonly USER_TOKEN_KEY = 'USER_TOKEN';
    private static instance: UserTokenStorage = new UserTokenStorage();

    private constructor() {
        if (UserTokenStorage.instance) {
            throw new Error("Error: Instantiation failed: Use UserTokenStorage.getInstance() instead of new.");
        }
        UserTokenStorage.instance = this;
    }

    public static getInstance(): UserTokenStorage {
        return UserTokenStorage.instance;
    }

    public setUserToken(token: string) {
        console.log("Your token is: " + token);
        if (sessionStorage.getItem(UserTokenStorage.USER_TOKEN_KEY) == null) {
            sessionStorage.setItem(UserTokenStorage.USER_TOKEN_KEY, token);
        }
    }

    public getUserToken() {
        return sessionStorage.getItem(UserTokenStorage.USER_TOKEN_KEY);
    }

    public clearStorage() {
        sessionStorage.clear();
    }
}
