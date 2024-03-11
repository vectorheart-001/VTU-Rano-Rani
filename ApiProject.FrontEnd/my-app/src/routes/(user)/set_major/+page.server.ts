import { redirect } from '@sveltejs/kit'
/** @type {import('./$types').Actions} */
export const load = async () => {
	throw redirect(302, '/')
}

export  const actions = {
	default:async({locals, cookies,request }) => {
		const user = locals.user
		const data = await request.formData()
		const majorId = data.get('majorid')
		const response = await fetch(`http://localhost:7162/User/set-major?` + new URLSearchParams({
			majorId:data.get('majorid')
		}),
        { 
            method: "Patch",
            headers: { 
				'Content-Type': 'application/json',
				'Authorization': `Bearer ${cookies.get('token')}`
			 },

			 
        },
		)
		
		if(response.status == 400 || response.status == 500)
		{
			console.log("Bad request")
		}
		else{
			
			
			throw redirect(308, '/profile')
		}
		
	},
}