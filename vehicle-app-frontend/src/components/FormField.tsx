import { TextField } from "@mui/material";

interface Props {
  name: string;
  value: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const FormField = ({ name, value, onChange }: Props) => {
  return (
    <TextField
      name={name}
      value={value}
      onChange={onChange}
      sx={{
        width: "100%",
        backgroundColor: "#092E49",
        border: "2px solid #5798C7",
        borderRadius: "0.5rem",
        input: {
          color: "#fff",
          fontSize: "0.875rem",
          lineHeight: "1.125rem",
          padding: "0.5rem 0.5rem 0.5rem 1rem",
        },
        "& .MuiOutlinedInput-notchedOutline": { border: "none" },
      }}
    />
  );
};

export default FormField;
