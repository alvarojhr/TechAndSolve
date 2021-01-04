import React from 'react'
import Axios from 'axios';
import Swal from 'sweetalert2'

export class FileUploader extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            identification: '',
            file: null
        };
    }

    async submit(e) {
        e.preventDefault();

        Swal.fire({
            title: 'Making Wilson rich',
            icon: 'info',
            showConfirmButton: false,
            allowOutsideClick: false,
            allowEscapeKey: false,
            onBeforeOpen: () => {
                Swal.showLoading();

                const url = '/FileUpload';
                const formData = new FormData()
                formData.append('Identification', this.state.identification)
                formData.append('File', this.state.file)

                return Axios.post(url, formData
                ).then(res => {
                    const FileDownload = require('js-file-download');

                    Axios({
                        url: url,
                        method: 'GET',
                        responseType: 'blob',
                    }).then((response) => {
                        FileDownload(response.data, 'lazy_loading_example_output.txt');
                        Swal.fire('Money is ready!', 'File downloaded with some tricks to be rich', 'success');
                    }).catch(error => {
                        Swal.fire('Bad news', 'Something happened :(', 'error');
                    });
                }).catch(error => {
                    Swal.fire('Bad news', 'Something happened :(', 'error');
                });
            }
        });

        
    }

    setFile(e) {
        this.setState({ file: e.target.files[0] });
    }

    handleInputChange(e) {
        this.setState({ identification: e.target.value });
    }

    render() {
        return (
            <div className="d-flex flex-column min-vh-100 justify-content-center align-items-center">
                <form onSubmit={e => this.submit(e)}>
                    <div className="form-group">
                    <h1>Help Wilson to be rich</h1>
                        <div className="row">

                <input placeholder="Please type your Identification Number" name="identification" value={this.state.identification}
                    onChange={e => this.handleInputChange(e)}
                                className="form-control" required
                            />
                        </div>
                    </div>
                    <div className="form-group">
                <input type="file" onChange={e => this.setFile(e)} accept="text/plain"
                        className="form-control-file" required
                        />
                    </div>
                    <div className="d-flex flex-row-reverse">
                        <div className="p-2">
                        <button type="submit" className="btn btn-primary">Make Rich!</button>
                    </div>

                        </div>
                </form>
              </div>
        );
    }
}