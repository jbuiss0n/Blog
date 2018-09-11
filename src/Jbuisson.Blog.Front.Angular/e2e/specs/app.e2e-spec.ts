import { browser, by, element } from 'protractor';

describe('the app', () => {

  beforeEach(() => {
    browser.get('/');
  });

  it('should not crash', () => {
    expect(element(by.css('app-root h1')).getText()).toEqual('Jbuisson.Blog.Angular');
  });
});
