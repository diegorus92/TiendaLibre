export interface IUserAccount{
    userEmail: string,
    password: string
}

export interface IUserAccountResponse{
    userId: number,
    userEmail: string,
    token: string
}