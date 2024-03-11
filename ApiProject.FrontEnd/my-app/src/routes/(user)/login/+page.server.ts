import { fail,error, redirect } from '@sveltejs/kit';
import type { Actions } from './$types';
import {successfullyRegistered} from '../../../store'

export const actions:Actions = {
  login: async ({ cookies, request }) => {
    const data = await request.formData();

    const email = data.get('email');
    const personalId = data.get('personalId');
    const payload = {
      email:String(email),
      persoanlId:String(personalId)
    }
    
    const response = await fetch(`http://localhost:7162/User/login`,
      { 
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      }
    )

    const json = await response.json();
    if (response.status === 200) {
      
      cookies.set('token', json.accessToken, {
          path: '/',
          httpOnly: true,
          sameSite: 'strict',
          maxAge: 60 * 60 * 24 * 1000
      });
      cookies.set('refreshToken', json.refreshToken, {
        path: '/',
        httpOnly: true,
        sameSite: 'strict',
        maxAge: 60 * 60 * 24 * 2000
      });
      throw redirect(302, "/");
    } else if (response.status == 400) {
      

      return fail(500, {

        error:"Неправилни данни"

      });
      


    }
    else{
      return fail(500,{error:"Грешен E-mail или ЕГН"});
    }
  }
  
}