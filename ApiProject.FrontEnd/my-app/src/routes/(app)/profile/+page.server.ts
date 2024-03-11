import { redirect } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';
/** @type {import('./$types').Actions} */

export const load = (async ({ locals }) => {
	const user = locals.user
    const res = (await fetch(`http://localhost:7162/Major/get-by-id?id=${user?.major}`))
	let major = await res.json()
	
    return {
		user,
        major
        
	};

}) satisfies PageServerLoad;

export  const actions = {
	default:async({locals, cookies,request }) => {
		const data = await request.formData();
        const formData = new FormData()
		const pdfFile = data.get('pdf')
        formData.append('formFile',pdfFile)
        const response = await fetch(`http://localhost:7162/User/confirm-payment`,
        { 
            method: "POST",
            
            headers: { 
				
				'Authorization': `Bearer ${cookies.get('token')}`
			 },
            body:formData

			 
        },
		)
		console.log(response.status)
		if(response.status == 400 || response.status == 500)
		{
			console.log("Bad request")
		}
		else{
			redirect(308,'/profile')
			
		}
		
	},
}