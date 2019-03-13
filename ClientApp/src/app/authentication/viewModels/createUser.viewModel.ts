export class CreateUserViewModel {
  constructor(
    public friendlyName: String,
    public email?: String,
    public password?: String,
    public passwordReEntered?: String
  ) {}
}
