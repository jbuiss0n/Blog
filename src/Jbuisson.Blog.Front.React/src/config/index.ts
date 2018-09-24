export interface IConfig {
  API_URL: string;
}

export default Object.assign({}, require('./config.' + process.env.NODE_ENV)) as IConfig;
